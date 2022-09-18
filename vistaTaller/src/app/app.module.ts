import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CitasComponent } from './citas/citas.component';
import { ClientesComponent } from './clientes/clientes.component';
import { ReportesComponent } from './reportes/reportes.component';
import { HeaderComponent } from './header/header.component';
import { InfoClienteComponent } from './info-cliente/info-cliente.component';
import { InfoTrabajadorComponent } from './info-trabajador/info-trabajador.component';
import { InfoCitaComponent } from './info-cita/info-cita.component';
import { CitaComponent } from './cita/cita.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CitasComponent,
    ClientesComponent,
    ReportesComponent,
    HeaderComponent,
    InfoClienteComponent,
    InfoTrabajadorComponent,
    InfoCitaComponent,
    CitaComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path:"", component:LoginComponent},
      {path:"login", component:LoginComponent},
      {path:"citas", component:CitasComponent},
      {path:"clientes", component:ClientesComponent},
      {path:"reportes", component:ReportesComponent},
      
      {path:"reportes", component:ReportesComponent},
      
      {path:"cliente", component:InfoClienteComponent},
      {path:"trabajador", component:InfoTrabajadorComponent},
      {path:"cita", component:InfoCitaComponent},
      {path: "prov", component:CitaComponent}
    ]),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
