import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/components/common/menuitem';


@Component({
  selector: 'menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  items:MenuItem[];

    ngOnInit() {
      this.items = [
        { label: 'Home', icon: 'pi pi-fw pi-home', routerLink:'home' },
        { label: 'Book', icon: 'pi pi-fw pi-plus', routerLink:'book' },
      ];
    }
}
