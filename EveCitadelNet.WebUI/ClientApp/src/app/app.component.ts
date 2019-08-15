import { Component, OnInit } from '@angular/core';
import { EveAuthService } from './eve-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.eveAuthService.getUrl()
      .subscribe(url => this.ssoUrl = url);
  }
  title = 'EveCitadelNets`'
  ssoUrl = '';

  constructor(private eveAuthService: EveAuthService) {
  }



  createUpperTitle(): string {
    return this.title.toUpperCase();
  }
}
