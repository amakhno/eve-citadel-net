import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EveAuthService {
  constructor(private http: HttpClient) { }

  getUrl() : Observable<string> {
    return this.http.get("get-callback-address", { responseType: 'text' });
  }
}
