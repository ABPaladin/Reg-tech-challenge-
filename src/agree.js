import "./style.css";
// agree.js
export default function Agree() {
    return /* html */ `
    <div class="container">
        <header class="navbar">
      <img src="../public/img/Logo.svg" >
    </header>
    <div class="card">
       <div class="faq">
      <h2>Acord de Consimțământ</h2>
    <div>
        <span>Prin accesarea și utilizarea Platformei „CyberCare for Businesses” și prin bifarea căsuței „Sunt de acord cu Politica de Confidențialitate”, dumneavoastră, în calitate de reprezent...</span>
        <span class="more" style="display:none;">
             ant legal al entității utilizatoare (denumită în continuare „Compania”), declarați și sunteți de acord cu următoarele:
</span>
<a href="#" class="read-more">Mai mult</a>
</div>
   
        <div class="tab">
          <input type="checkbox" id="faq1">
          <label for="faq1">1. Acceptarea Politicii de Confidențialitate</label>
          <div class="tab-content">
            Am citit și am înțeles pe deplin Politica de Confidențialitate a Platformei „CyberCare for Businesses”, care detaliază modul în care Orange System colectează, prelucrează, stochează și partajează datele colectate, inclusiv datele cu caracter personal, în conformitate cu Legea Nr. 48/2023 privind securitatea cibernetică și Hotărârea Guvernului Nr. NU-49-MDED-2025.
          </div>
        </div>

        <div class="tab">
          <input type="checkbox" id="faq2">
          <label for="faq2">2. Consimțământ pentru Colectarea și Prelucrarea Datelor</label>
          <div class="tab-content">
            Consimt în mod expres ca Orange System să colecteze și să prelucreze datele Companiei (inclusiv datele de înregistrare, auto-evaluările de securitate, rezultatele verificărilor automate de igienă cibernetică, rapoartele de incidente cibernetice și rapoartele de audit) în scopurile specificate în Politica de Confidențialitate, inclusiv pentru:
    ◦ Asigurarea conformității Companiei cu obligațiile legale în materie de securitate cibernetică.
    ◦ Gestionarea riscurilor și măsurilor de securitate.
    ◦ Raportarea obligatorie a incidentelor cibernetice către Agenția pentru Securitate Cibernetică (ASC) și/sau Centrul Guvernamental de Răspuns la Incidente Cibernetice (CERT-Gov).
    ◦ Generarea de recomandări și ghiduri personalizate pentru îmbunătățirea securității cibernetice.
    ◦ Analize interne și statistici agregate pentru îmbunătățirea Platformei.
          </div>
        </div>

        <div class="tab">
          <input type="checkbox" id="faq3">
          <label for="faq3">3. Prelucrarea Datelor ca Obligație Legală</label>
          <div class="tab-content">
            Am citit și am înțeles pe deplin Politica de Confidențialitate a Platformei „CyberCare for Businesses”, care detaliază modul în care Orange System colectează, prelucrează, stochează și partajează datele colectate, inclusiv datele cu caracter personal, în conformitate cu Legea Nr. 48/2023 privind securitatea cibernetică și Hotărârea Guvernului Nr. NU-49-MDED-2025.
          </div>
        </div>
        <div class="tab">
          <input type="checkbox" id="faq4">
          <label for="faq4">4. Acord pentru Partajarea Datelor cu Autoritățile</label>
          <div class="tab-content">
            Sunt de acord cu partajarea datelor Companiei cu entitățile menționate în Politica de Confidențialitate (ex: ASC, CERT-Gov, SIS, alte autorități publice), în măsura în care această partajare este necesară pentru îndeplinirea obligațiilor legale sau pentru atingerea scopurilor legitimate ale Platformei, conform descrierii din Politica de Confidențialitate.
          </div>
        </div>
        <div class="tab">
          <input type="checkbox" id="faq5">
          <label for="faq5">5. Confirmarea Autorității și a Consimțământului</label>
          <div class="tab-content">
            Confirm că sunt autorizat să ofer acest consimțământ în numele Companiei și că toate datele furnizate sunt veridice și complete.

Prin continuarea utilizării Platformei, îmi dau consimțământul pentru prelucrarea datelor în condițiile expuse în prezenta Politică de Confidențialitate și acest Acord de Consimțământ.
</div>
        </div>
      </div>
</div>
<footer class="footer">
      <span>© 2025 Toate drepturile sunt rezervate.</span>
      <a href="#">Suport</a>
    </footer>
  `;
}
