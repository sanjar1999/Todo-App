import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BsModalService } from 'ngx-bootstrap/modal';
import { of } from 'rxjs';
import { TagsDto } from 'src/app/web-api-client';

import { TagComponent } from './tag.component';

describe('TagComponent', () => {
  let component: TagComponent;
  let fixture: ComponentFixture<TagComponent>;
  let tagsToTest = [
    {
      id: 1,
      tagName: 'Tag 1'
    } as TagsDto,
    {
      id: 2,
      tagName: 'Tag 2'
    } as TagsDto,
    {
      id: 3,
      tagName: 'Tag 3'
    } as TagsDto
  ];

  let tagToTest = {
      tagName: "Tag to Create"
  } as TagsDto

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule], 
      providers: [BsModalService],
      declarations: [TagComponent]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set values to tags on ngOnInit', () => {
    spyOn(component.tagsClient, 'getTags').and.returnValue(of (tagsToTest));
    component.ngOnInit();
    expect(component.tags).toEqual(tagsToTest);
  })

  it('should delete the selected tag', () => {
    spyOn(component.tagsClient, 'deleteTag').and.returnValue(of(null));
    component.tags = tagsToTest;
    let tagToDelete = tagsToTest[1];
    component.deleteTag(tagToDelete);
    expect(component.tags.length).toBe(2);
  })

  it('should call the delete method only once', () => {
    spyOn(component.tagsClient, 'deleteTag').and.returnValue(of(null));
    component.tags = tagsToTest;
    let tagToDelete = tagsToTest[0];
    component.deleteTag(tagToDelete);
    expect(component.tagsClient.deleteTag).toHaveBeenCalledTimes(1);
  })

  it('should delete the actual selected tag in tags', () => {
    spyOn(component.tagsClient, 'deleteTag').and.returnValue(of(null));
    component.tags = tagsToTest;
    let tagToDelete = tagsToTest[1];
    component.deleteTag(tagToDelete);
    expect(tagsToTest.includes(tagToDelete) == false);
  });

  it('should call the create method only once', () => {
    spyOn(component.tagsClient, 'createTag').and.returnValue(of(null));
    component.addTag();
    expect(component.tagsClient.createTag).toHaveBeenCalledTimes(1);
  });

  it('should create new tag', () => {
    spyOn(component.tagsClient, 'createTag').and.returnValue(of(null));
    component.tagsClient.createTag(tagToTest);
    component.addTag();
    expect(component.tags.includes(tagToTest) == true);
  });

  it('should check the length of tags list after adding new tag', () => {
    spyOn(component.tagsClient, 'createTag').and.returnValue(of(null));
    component.tagsClient.createTag(tagToTest);
    component.addTag();
    expect(component.tags.length).toBe(1);
  });
});
