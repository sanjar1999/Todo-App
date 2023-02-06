import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TodoComponent } from './todo.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { of } from 'rxjs';
import { TagsDto, TodoItemDto, TodoListDto } from '../web-api-client';
import { EventEmitter } from '@angular/core';

describe('TodoComponent', () => {
    let component: TodoComponent;
    let fixture: ComponentFixture<TodoComponent>;
    let todoToTest = {
      id: 1,
      title: "todo test 1",
      listId: 1,
      colourCode: "#FF5733"
    } as TodoItemDto

    let selectedListTest: TodoListDto;
    
    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [HttpClientModule, ReactiveFormsModule], 
        providers: [BsModalService],
        declarations: [ TodoComponent ]
      })
      .compileComponents();
    });
  
    beforeEach(() => {
      fixture = TestBed.createComponent(TodoComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();

      selectedListTest = {
        id: 1,
        title: "list to test",
        items: [
          {
            id: 1,
            title: "todo test 1",
            listId: 1,
            colourCode: "#FFFFFF",
            todoItemTag: [
              {
                id: 1,
                tagName: 'test tag 1'
              } as TagsDto
            ]
          } as TodoItemDto,
          {
            id: 2,
            title: "todo test 2",
            listId: 1,
            colourCode: "#FFFFFF",
          } as TodoItemDto,
          {
            id: 3,
            title: "todo test 3",
            listId: 1,
            colourCode: "#FFFFFF"
          } as TodoItemDto
        ]
      } as TodoListDto;
    });
  
    it('should create', () => {
      expect(component).toBeTruthy();
    });

    it('should delete the selected item', () => {
      spyOn(component.itemsClient, 'delete').and.returnValue(of(null));
      component.selectedList = selectedListTest;
      selectedListTest.items[0] = todoToTest;
      component.deleteItem(todoToTest);
      expect(selectedListTest.items.length).toBe(2);
    });

    it('should call the delete method only once', () => {
      spyOn(component.itemsClient, 'delete').and.returnValue(of(null));
      component.selectedList = selectedListTest;
      selectedListTest.items[0] = todoToTest;
      component.deleteItem(todoToTest);
      expect(component.itemsClient.delete).toHaveBeenCalledTimes(1);
    });

    it('should delete the actual selected item in items', () => {
      spyOn(component.itemsClient, 'delete').and.returnValue(of(null));
      component.selectedList = selectedListTest;
      selectedListTest.items[0] = todoToTest;
      component.deleteItem(todoToTest);
      expect(selectedListTest.items.includes(todoToTest) == false);
    });

    it('should change the colour of item', () => {
      spyOn(component.itemsClient, "updateItemDetails").and.returnValue(of(null));
      component.selectedItem = selectedListTest.items[0];
      component.showItemDetailsModal(null, component.selectedItem);
      component.itemDetailsFormGroup.value.colourCode = "#FF5733";
      component.updateItemDetails()
      expect(component.selectedItem.colourCode == "#FF5733")
    });

    it('test filter', () => {
      component.selectedList = selectedListTest;
      let testEvent = {
        value: {
          id: 1
        }
      }
      component.onChange(testEvent)
      expect(component.filteredTodo.length == 1);
      expect(component.filteredTodo[0]).toBe(selectedListTest.items[0])
    });
  });