import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirplaneComponent } from './airplane/airplane.component';
import { AirplaneCriarComponent } from './airplane-criar/airplane-criar.component';


const routes: Routes = [
  { path: '', component: AirplaneComponent },
  { path: 'criar', component: AirplaneCriarComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AirplaneRoutingModule { }
