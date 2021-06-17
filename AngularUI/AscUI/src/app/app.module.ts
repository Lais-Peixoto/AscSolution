import { NgModule, Pipe, PipeTransform } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunoComponent } from './aluno/aluno.component';
import { ShowComponent } from './aluno/show/show.component';
import {SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CompeonatoComponent } from './compeonato/compeonato.component';
import { ShowCampComponent } from './compeonato/show-camp/show-camp.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent,
    ShowComponent,
    CompeonatoComponent,
    ShowCampComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})

export class AppModule { }
