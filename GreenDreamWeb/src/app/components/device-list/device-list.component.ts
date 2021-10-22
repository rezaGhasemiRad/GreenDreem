import {Component, OnInit} from '@angular/core';
import {Device} from "../../models/device.model";
import {DeviceService} from "../../services/device.service";

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {

  devices?: Device[] = [];
  currentDevice: Device = {};
  currentIndex = -1;
  name = '';

  constructor(private deviceService: DeviceService) { }

  ngOnInit(): void {
    this.getAllDevices();
  }

  getAllDevices(): void {
    this.deviceService.getAll()
      .subscribe(
        (data) => {
          this.devices = data.devices;
        },
        error => {
          console.log(error);
        });
  }
  setAsActiveDevice(device: Device, index: number): void {
    this.currentDevice = device;
    this.currentIndex = index;
  }


}
