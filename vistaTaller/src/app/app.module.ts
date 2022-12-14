import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CitasComponent } from './citas/citas.component';
import { ClientesComponent } from './clientes/clientes.component';
import { ReportesComponent } from './reportes/reportes.component';
import { HeaderComponent } from './header/header.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { InfoClienteComponent } from './info-cliente/info-cliente.component';
import { InfoTrabajadorComponent } from './info-trabajador/info-trabajador.component';
import { InfoCitaComponent } from './info-cita/info-cita.component';
import { CitaComponent } from './cita/cita.component';
import { FormsModule } from '@angular/forms';
import { VistaTallerComponent } from './vista-taller/vista-taller.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CitasComponent,
    ClientesComponent,
    ReportesComponent,
    HeaderComponent,
    TrabajadoresComponent,
    InfoClienteComponent,
    InfoTrabajadorComponent,
    InfoCitaComponent,
    CitaComponent,
    VistaTallerComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path:"", component:LoginComponent},
      {path:"login", component:LoginComponent},
      {path:"citas", component:CitasComponent},
      {path:"clientes", component:ClientesComponent},
      {path:"reportes", component:ReportesComponent},
      {path:"trabajadores", component:TrabajadoresComponent},
      
      {path:"cliente", component:InfoClienteComponent},
      {path:"trabajador", component:InfoTrabajadorComponent},
      {path:"cita", component:InfoCitaComponent},
      {path: "prov", component:CitaComponent},

      {path:"vistaTaller", component:VistaTallerComponent}
    ]),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
