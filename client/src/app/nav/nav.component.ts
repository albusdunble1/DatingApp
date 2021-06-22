import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  // loggedIn: boolean;
  // currentUser$: Observable<User>;

  // constructor(private accountService: AccountService) { }
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      // this.loggedIn = true;
    }, error => {
      console.log(error);
    })
  }

  logout(){
    this.accountService.logout();
    // this.loggedIn = false;
  }

  // old method (not so clean, async is cleaner and auto unsubscribes)

  // getCurrentUser(){
  //   this.accountService.currentUser$.subscribe(user => {
  //     // !! converts a value into a boolean, so null(false) and any other value (true)
  //     this.loggedIn = !!user;
  //   }, error => {
  //     console.log(error);
  //   })
  // }

}
