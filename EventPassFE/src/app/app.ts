import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/header/header";
import { FooterComponent } from "./shared/footer/footer";


@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    HeaderComponent,
    FooterComponent
],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'EventPassFE';
}
