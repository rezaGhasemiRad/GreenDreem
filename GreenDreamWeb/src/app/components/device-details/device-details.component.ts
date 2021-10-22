import { Component, OnInit } from '@angular/core';
import {Device} from "../../models/device.model";
import {DeviceService} from "../../services/device.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  currentDevice : Device = {
    name: '',
    description: ''
  };
  message = '';

  constructor(private deviceService: DeviceService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getOnDevice(this.route.snapshot.params.id);
  }

  getOnDevice(id: string): void {
    this.deviceService.get(id)
      .subscribe(
        data => {
          this.currentDevice = data.device;
          console.log(data.device);
        },
        error => {
          console.log(error);
        });
  }

  updateDevice(): void {
    this.message = '';

    this.deviceService.update(this.currentDevice.id, this.currentDevice)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/device']);
        },
        error => {
          console.log(error);
        });
  }

  deleteDevice(): void {
    this.deviceService.delete(this.currentDevice.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/device']);
        },
        error => {
          console.log(error);
        });
  }
}
