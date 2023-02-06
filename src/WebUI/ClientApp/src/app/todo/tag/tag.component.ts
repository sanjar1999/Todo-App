import { Component, OnInit } from '@angular/core';
import { CreateTagCommand, TagsClient, TagsDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.scss']
})
export class TagComponent implements OnInit {
  tags: TagsDto[] = [];

  tag = {
    id: 0,
    tagName: '' 
  } as TagsDto;

  constructor(
    public tagsClient: TagsClient
  ) { }

  ngOnInit(): void {
    this.tagsClient.getTags().subscribe(
      result => {
        this.tags = result;
      }
    )
  }

  addTag(): void {
    this.tagsClient.createTag(this.tag as CreateTagCommand).subscribe(
      result => {
        this.tag.id = result;
        this.tags.push(this.tag);
        this.tag = {
          id: 0,
          tagName: '' 
        } as TagsDto
      },
      error => console.log(error)
    )
  }

  deleteTag(tag: TagsDto) {
    if (tag.id === 0) {
      const itemIndex = this.tags.indexOf(this.tag);
      this.tags.splice(itemIndex, 1);
    } else {
      this.tagsClient.deleteTag(tag.id).subscribe(() => {
          this.tags = this.tags.filter(
          t => t.id !== tag.id
        )},
        error => console.error(error)
      );
    }
  }
}
