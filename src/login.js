import "./style.css";
import Policy from "./policy.js";
import Agree from "./agree.js";
// login.js
export default function Login() {
    return /* html */ `
    <div class="container">
        <!-- Navbar -->
        <header class="navbar">
          <img src="../public/img/Logo.svg" >
        </header>
    
        <!-- Login card -->
        <main class="card">
          <h2>Autentifică-te în cabinet</h2>
          <form>
            <input type="password" placeholder="Parola" required>
    
            <label class="checkbox">
              <input type="checkbox" required>
              Sunt de acord cu <a href="./agree.js" data-link>Termenii și Condițiile</a> și <a href="./policy.js" data-link>Politica de Confidențialitate</a>
            </label>
    
            <button type="submit">Continue</button>
          </form>
        </main>
    
        <!-- Footer -->
        <footer class="footer">
          <span>© 2025 Toate drepturile sunt rezervate.</span>
          <a href="#">Suport</a>
        </footer>
    </div>
    `;
}
document.addEventListener("click", (e) => {
    if (e.target instanceof Element && e.target.matches("[data-link]")) {
        e.preventDefault();
        const path = e.target.getAttribute("href");

        if (path === "./policy.js") {
            document.querySelector("#app").innerHTML = Policy();
        } else if (path === "./agree.js") {
            document.querySelector("#app").innerHTML = Agree();
        }
    }
});
