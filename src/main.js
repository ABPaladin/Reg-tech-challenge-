import './style.css'
import { setupCounter } from './counter.js'

document.querySelector('#app').innerHTML = `
  <div>
    <h1>Welcome!</h1>
    <div class="card">
      <p>
      Input for ip
    </p>  
        
    <button type="button">Submit</button>
      </div>
    <p class="read-the-docs">
      a
    </p>
  </div>
`

setupCounter(document.querySelector('#counter'))
