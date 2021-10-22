import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {DeviceListComponent} from "./components/device-list/device-list.component";
import {DeviceDetailsComponent} from "./components/device-details/device-details.component";
import {CreateDeviceComponent} from "./components/create-device/create-device.component";

const routes: Routes = [
  { path: '', redirectTo: 'device', pathMatch: 'full' },
  { path: 'device', component: DeviceListComponent },
  { path: 'device/:id', component: DeviceDetailsComponent },
  { path: 'create', component: CreateDeviceComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
