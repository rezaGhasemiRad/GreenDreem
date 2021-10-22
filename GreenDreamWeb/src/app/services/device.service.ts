import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Device, GetAllResponseModel, GetOneResponseModel} from "../models/device.model";
import {Observable} from "rxjs";

const baseUrl = 'http://localhost:5000/device';

@Injectable({
  providedIn: 'root'
})

export class DeviceService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<GetAllResponseModel> {
    return this.http.get<GetAllResponseModel>(baseUrl);
  }

  get(id: any): Observable<GetOneResponseModel> {
    return this.http.get<GetOneResponseModel>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
