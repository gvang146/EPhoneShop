import { Component } from '@angular/core';
import { FilterPipe } from './shared/filter.pipe';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ephoneshop';
}