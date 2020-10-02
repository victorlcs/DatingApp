import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  users: any;

  constructor(private http: HttpClient) {

  }
  ngOnInit() {
    this.http.get('https://localhost:5001/api/user').subscribe(value => {
        this.users = value;
    });
  }
}
