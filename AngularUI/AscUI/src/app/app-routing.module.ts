import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoComponent } from './aluno/aluno.component';
import { CompeonatoComponent } from './compeonato/compeonato.component';

const routes: Routes = [
  {path:'alunos', component: AlunoComponent},
  {path:'campeonato', component:CompeonatoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
