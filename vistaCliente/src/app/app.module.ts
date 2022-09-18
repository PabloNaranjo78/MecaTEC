import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';

import { CitasComponent } from './citas/citas.component';
import { ReportesComponent } from './reportes/reportes.component';

import { HeaderComponent } from './header/header.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ChangePasswordComponent } from './change-password/change-password.component';



@NgModule({
  declarations: [
    AppComponent,
    ReportesComponent,
    LoginComponent,
    HeaderComponent,
    CitasComponent,
    EditProfileComponent,
    ChangePasswordComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path:"", component:LoginComponent},
      {path:"login", component:LoginComponent},
      {path:"citas", component:CitasComponent},
      {path:"reportes", component:ReportesComponent},
      
      {path:"reportes", component:ReportesComponent},
      {path:"header", component:HeaderComponent},
      {path:"edit-profile", component:EditProfileComponent},
      {path:"change-password", component:ChangePasswordComponent},

      
    ]),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
