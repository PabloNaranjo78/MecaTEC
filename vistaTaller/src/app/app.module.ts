import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CitasComponent } from './citas/citas.component';
import { ClientesComponent } from './clientes/clientes.component';
import { ReportesComponent } from './reportes/reportes.component';
import { HeaderComponent } from './header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CitasComponent,
    ClientesComponent,
    ReportesComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path:"", component:LoginComponent},
      {path:"login", component:LoginComponent},
      {path:"citas", component:CitasComponent},
      {path:"clientes", component:ClientesComponent},
      {path:"reportes", component:ReportesComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
