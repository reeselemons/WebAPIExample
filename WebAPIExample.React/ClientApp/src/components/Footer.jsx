import React, { Component } from 'react';
import './Footer.css';

export class Footer extends Component {
  static displayName = Footer.name;

  constructor (props) {
    super(props);

  }

  render() {
    return (<><footer class="footer py-3">
    <div class="container">
        <p class="small mb-0 text-light">
            &copy; <script>{new Date().getFullYear()}</script><i class="ti-heart text-danger"></i><a href="http://mauriceblemons.com" target="_blank"><span class="text-danger" title="Maurice B Lemons">Maurice Lemons</span></a>
        </p>
    </div>
</footer>
</>);
  }
}
