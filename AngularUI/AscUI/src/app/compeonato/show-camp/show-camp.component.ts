import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-camp',
  templateUrl: './show-camp.component.html',
  styleUrls: ['./show-camp.component.css']
})
export class ShowCampComponent implements OnInit {

  constructor(private service: SharedService) { }

  CompetidoresList:any=[];

  ngOnInit(): void {
    this.refreshCompetidoresList();
  }

  refreshCompetidoresList(){
    this.service.GetCompeticao().subscribe(data =>{
      this.CompetidoresList = data;
    });
  }

}
