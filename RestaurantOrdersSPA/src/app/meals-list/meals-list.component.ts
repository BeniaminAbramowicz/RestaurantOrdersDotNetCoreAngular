import { Component, OnInit } from '@angular/core';
import { MealsService } from '../_services/meals.service';

@Component({
  selector: 'app-meals-list',
  templateUrl: './meals-list.component.html',
  styleUrls: ['./meals-list.component.css']
})
export class MealsListComponent implements OnInit {
  columnDefs = [
    { headerName: 'Id', field: 'id', resizable: true },
    { headerName: 'Name', field: 'name', resizable: true, editable: true, cellEditor: 'agSelectCellEditor', cellEditorParams: {values: ['Pork chop with potatoes', 'Tomato soup', 'Cheeseburger', 'French fries'] }},
    { headerName: 'Unit price', field: 'unitPrice', resizable: true, editable: true }
  ];

  rowData:any;

  constructor(private mealsService: MealsService) { }

  ngOnInit() {
    this.mealsService.GetAllMeals().subscribe((data) => {
      console.log(data);
      this.rowData = data;
    });
  }

}
