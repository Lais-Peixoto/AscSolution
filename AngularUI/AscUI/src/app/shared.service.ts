import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:15551";

  constructor(private http: HttpClient) { }
  
  // Consumindo a API:
  // GET:
  GetAluno():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/api/Alunos');
  }
   // GET:
   GetCompeticao():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/campeonato');
  }
 // POST:
  AddAluno(val:any){
    return this.http.post(this.APIUrl+'/Alunos', val);
  }
 // PUT:
  UpdateAluno(val:any){
    return this.http.put(this.APIUrl+'/Alunos', val);
  }
 // DELETE:
  DeleteAluno(val:any){
    return this.http.delete(this.APIUrl+'/Alunos', val);
  }

}
