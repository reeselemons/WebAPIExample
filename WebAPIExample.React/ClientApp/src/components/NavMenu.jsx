import React, { Component } from 'react';
import profilepic from '../public/imgs/profile-pic.jpg';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

  }

  render() {
    return (<><a href="components.html" class="btn btn-primary btn-component" data-spy="affix" data-offset-top="600"><i class="ti-shift-left-alt"></i> Components</a>
    <header class="header">
        <div class="container">
            <div class="header-content">
                <h4 class="header-subtitle">Welcome to my portfolio</h4>
                <h1 class="header-title">Maurice Lemons</h1>
                <h6 class="header-mono">Fullstack Software Engineer</h6>
                {/*<button class="btn btn-primary btn-rounded"><i class="ti-printer pr-2"></i>Print Resume</button>*/}
            </div>
        </div>
    </header>
        <nav class="navbar sticky-top navbar-expand-lg navbar-light bg-white" data-spy="affix" data-offset-top="510">
    <div class="">
            <button class="navbar-toggler ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse mt-sm-20 navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                    </li>
                </ul>
                <ul class="navbar-nav brand">
                    <img src={profilepic} alt="" class="brand-img" />
                    <li class="brand-txt">
                        <h5 class="brand-title">Maurice Lemons</h5>
                        <div class="brand-subtitle">Software Engineer | Web Developer</div>
                    </li>
                </ul>
                <ul class="navbar-nav ml-auto">
                </ul>
            </div>
        </div>
    </nav></>);
  }
}
