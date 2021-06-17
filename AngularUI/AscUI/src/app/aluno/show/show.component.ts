import { Component, OnInit} from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private service: SharedService) { }

  AlunoList:any=[];
  AnoLetivoSituacaoFilter:string="";
  AnoLetivoMediaFilter:string="";
  AnoLetivoSemFilter:any=[];

  ngOnInit(): void {
    this.refreshAlunoList();
  }

  refreshAlunoList(){
    this.service.GetAluno().subscribe(data =>{
      this.AlunoList = data;
      this.AnoLetivoSemFilter=data;
    });
  }

  FilterFunction(){
    var AnoLetivoSituacaoFilter = this.AnoLetivoSituacaoFilter;

    this.AlunoList = this.AnoLetivoSemFilter.filter(function (el: { situacao: { toString: () => string; }; media: { toString: () => string; }; provaFinal: { toString: () => string; }; }){
      return el.situacao.toString().toLowerCase().includes(
        AnoLetivoSituacaoFilter.toString().trim().toLowerCase()
      )
    });
  }

  sortResult(prop: string | number, asc: any){
    this.AlunoList = this.AnoLetivoSemFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
        return (a[prop]>b[prop]) ?1: ((a[prop]<b[prop]) ?-1: 0);
      } else {
        return (b[prop]>a[prop]) ?1: ((b[prop]<a[prop]) ?-1: 0);
      }
    })
  }
}
