import "./style.css";
// policy.js
export default function Policy() {
    return /* html */ `
    <div class="container">
        <header class="navbar">
      <img src="../public/img/Logo.svg" >
    </header>
    <div class="card">
      <h2>Politica de Confidențialitate</h2>
    
    <div class="faq">
        <div style="margin-bottom: 20px;">
        <span>Prezenta Politică de Confidențialitate (denumită în continuare „Politica”) descrie modul în care Orange System colectează, utilizează, stochează, partajează și protejează informa...</span>
        <span class="more" style="display:none;">
             țiile și datele prelucrate prin intermediul platformei „CyberCare for Businesses” (denumită în continuare „Platforma”). Platforma este concepută pentru a asista întreprinderile din Republica Moldova în conformitate cu Legea Nr. 48/2023 privind securitatea cibernetică și Hotărârea Guvernului Nr. NU-49-MDED-2025 privind modul de realizare a obligațiilor de asigurare a securității cibernetice de către furnizorii de servicii în sectoarele critice.
Ne angajăm să protejăm confidențialitatea și securitatea datelor dumneavoastră și să respectăm legislația aplicabilă privind protecția datelor cu caracter personal.
</span>
<a href="#" class="read-more">Mai mult</a>
</div>
        <div class="tab">
          <input type="checkbox" id="faq1">
          <label for="faq1">1. Operatorul de Date</label>
          <div class="tab-content">
            Operatorul de date responsabil pentru prelucrarea datelor prin intermediul Platformei este Orange System.
          </div>
        </div>
        <div class="tab">
          <input type="checkbox" id="faq2">
          <label for="faq2">2. Tipuri de Date Colectate și Prelucrate</label>
          <div class="tab-content">
            Platforma colectează și prelucrează diverse categorii de date, atât non-personale, cât și cu caracter personal, în scopul asigurării conformității
            cu legislația în vigoare și a furnizării serviciilor:
• Informații de Înregistrare a Companiei:
    ◦ Denumirea completă a persoanei juridice.
    ◦ Numărul de înregistrare (IDNO).
    ◦ Adresa juridică și locația principalelor active IT (dacă este cazul).
    ◦ Datele de contact ale persoanei responsabile de securitatea cibernetică/IT (nume, funcție, e-mail, telefon).
    ◦ Dimensiunea întreprinderii (întreprindere mijlocie sau care depășește criteriile pentru întreprinderile mijlocii, conform legislației privind IMM-urile).
    ◦ Sectorul de activitate și serviciile prestate (dacă intră în unul sau mai multe sectoare sau subsectoare critice, stabilite de Guvern, cum ar fi energie, transport, bancar, sănătate, infrastructură digitală, management servicii TIC, furnizori digitali).
• Date privind Starea Curentă a Securității Cibernetice (Auto-evaluare):
    ◦ Informații privind deținerea unei certificări ISO/IEC 27001 și o copie a certificatului valabil, dacă este cazul.
    ◦ Detalii despre evaluările de risc efectuate pentru rețele și sisteme informatice.
    ◦ Informații despre planurile de tratare a riscurilor identificate.
    ◦ Măsuri de securitate cibernetică deja implementate (ex: firewall-uri, antivirus, sisteme de detectare a intruziunilor, autentificare multifactorială).
• Rezultatele Verificărilor Automate de Igienă Cibernetică (conform Articolului 11 al Legii Nr. 48/2023):
    ◦ Inventarul expunerii la Internet (porturi deschise, servicii, bannere).
    ◦ Antetele de securitate web (HTTPS, CSP, X-Frame-Options etc.).
    ◦ Amprenta CVE (vulnerabilități cunoscute în serviciile publice, ex: Bitrix24).
    ◦ Politicile TLS (versiuni, stare certificat, HSTS).
    ◦ Autentificarea e-mailului (validare SPF/DKIM/DMARC).
    ◦ Dovada colectării jurnalelor/centralizării evenimentelor (SIEM), inclusiv tipurile de jurnale colectate (trafic de rețea, acces la sisteme, evenimente de autentificare, acces privilegiat, modificări fișiere critice, evenimente de securitate, utilizarea resurselor, acces fizic etc.).
• Date de Raportare a Incidentelor (conform Articolului 12 al Legii Nr. 48/2023):
    ◦ Notificarea inițială, actualizări și rapoarte finale privind incidentele cibernetice, inclusiv cele cu impact semnificativ sau recurente (≥2 în 6 luni cu aceeași cauză).
    ◦ Informații despre suspiciuni de acte ilegale sau impact transfrontalier al incidentului.
    ◦ Detalii privind cauzele, durata soluționării, măsurile aplicate și impactul incidentului cibernetic.
    ◦ Pot include informații ce vizează „exfiltrarea secretelor comerciale”.
• Rapoarte de Audit și Evaluare a Conformității:
    ◦ Rapoarte de audit extern și examinări independente privind securitatea informațiilor, efectuate de persoane certificate în domeniul auditului securității informațiilor.
          </div>
        </div>
        <div class="tab">
          <input type="checkbox" id="faq3">
          <label for="faq3">3. Scopurile Colectării și Prelucrării Datelor</label>
          <div class="tab-content">
            Prelucrarea datelor se realizează în principal pentru următoarele scopuri:
• Asigurarea Conformității Legale: Ajutarea furnizorilor de servicii să respecte Legea Nr. 48/2023 și Hotărârea Guvernului Nr. NU-49-MDED-2025, inclusiv măsurile de securitate și obligațiile de notificare a incidentelor cibernetice.
• Evaluarea Riscurilor și Gestionarea Securității: Efectuarea de evaluări de risc și stabilirea măsurilor tehnice și organizaționale adecvate și proporționale pentru gestionarea riscurilor la adresa rețelelor și sistemelor informatice.
• Monitorizarea și Îmbunătățirea Continuă: Monitorizarea continuă a conformității cu politicile de securitate și a eficacității măsurilor de gestionare a riscurilor în materie de securitate cibernetică, cu angajamentul de îmbunătățire continuă.
• Raportarea Incidentelor Cibernetice: Facilitarea procesului de raportare în trei etape (notificare inițială, actualizare, raport final) către Agenția pentru Securitate Cibernetică (ASC) sau Centrul Guvernamental de Răspuns la Incidente Cibernetice (CERT-Gov).
• Furnizarea de Recomandări și Ghiduri: Generarea de recomandări clare, „pe înțelesul omului” și resurse de instruire pentru proprietarii de afaceri non-tehnici, bazate pe rezultatele scanărilor și ale chestionarelor.
• Analiză Internă și Statistică: Datele colectate pot fi utilizate pentru analize agregate, statistici și pentru îmbunătățirea Platformei și a serviciilor oferite.
• Răspuns la Amenințări Semnificative: Asistarea în identificarea și răspunsul la amenințări cibernetice semnificative și incidente.
          </div>
        </div>
                <div class="tab">
          <input type="checkbox" id="faq4">
          <label for="faq4">4. Temeiul Legal al Prelucrării Datelor</label>
          <div class="tab-content">
            Prelucrarea datelor se bazează pe următoarele temeiuri legale:
• Obligație Legală: Prelucrarea este necesară pentru respectarea obligațiilor legale ce revin furnizorilor de servicii conform Legii Nr. 48/2023 privind securitatea cibernetică și Hotărârii Guvernului Nr. NU-49-MDED-2025. Aceasta include cerințele de implementare a măsurilor de securitate și obligațiile de notificare a incidentelor.
• Interes Public: Prelucrarea datelor este efectuată în interes public, având în vedere importanța asigurării unui nivel înalt de securitate cibernetică la nivel național și protejarea infrastructurilor critice și a societății în ansamblu.
• Interes Legitim: Prelucrarea poate fi necesară pentru interesele legitime ale Orange System, cum ar fi îmbunătățirea serviciilor Platformei, prevenirea fraudei și asigurarea securității operațiunilor noastre, cu respectarea drepturilor și libertăților dumneavoastră fundamentale.
• Consimțământ: În cazurile în care prelucrarea datelor nu este impusă de o obligație legală sau de un interes legitim, vom solicita consimțământul dumneavoastră explicit, conform secțiunii „Acord de Consimțământ” de mai jos.
</div>
</div>
        <div class="tab">
          <input type="checkbox" id="faq5">
          <label for="faq5">5. Destinatarii Datelor și Partajarea Acestora</label>
          <div class="tab-content">
           Datele colectate pot fi partajate cu următoarele entități:
• Agenția pentru Securitate Cibernetică (ASC): Furnizorii de servicii sunt obligați să informeze ASC despre incidentele cibernetice cu impact semnificativ, fără întârzieri nejustificate și nu mai târziu de 24 de ore de la luarea la cunoștință. Platforma facilitează exportul rapoartelor în formate JSON/PDF sau transmiterea automată (dacă este implementată) către ASC. ASC are rol de supraveghere și control.
• Centrul Guvernamental de Răspuns la Incidente Cibernetice (CERT-Gov): Persoanele juridice de drept public notifică CERT-Gov, care, la rândul său, informează ASC despre incidente.
• Serviciul de Informații și Securitate (SIS): ASC informează SIS despre incidentele cibernetice cu impact semnificativ care au vizat obiective ale infrastructurii critice. SIS furnizează liste ale operatorilor de infrastructură critică către autoritatea competentă.
• Organul de Control al Prelucrărilor de Date cu Caracter Personal: În cazul în care Orange System ia cunoștință că o încălcare a obligațiilor de securitate cibernetică poate atrage și o încălcare a legislației privind protecția datelor cu caracter personal, va informa organul de control.
• Alte Autorități Publice Relevante: ASC interacționează cu autoritățile publice și instituțiile publice.
• Parteneri de Afaceri și Furnizori de Servicii Terți: Pentru operarea și îmbunătățirea Platformei (ex: găzduire cloud, servicii de analiză), cu asigurarea unor garanții contractuale stricte privind confidențialitatea și securitatea datelor.
• Schimb Voluntar de Informații: Cu acordul dumneavoastră, datele relevante privind amenințările, vulnerabilitățile și incidentele cibernetice pot fi partajate voluntar cu alți furnizori de servicii sau organizații, mediate de ASC, pentru a spori nivelul general de securitate cibernetică. Aceste schimburi pot necesita acorduri specifice de partajare a informațiilor.
</div></div>
<div class="tab">
          <input type="checkbox" id="faq6">
          <label for="faq6">6. Transferul Internațional de Date</label>
          <div class="tab-content">
           Datele pot fi transferate la nivel internațional în contextul cooperării ASC cu alte state și organizații internaționale, cu respectarea cadrului legal aplicabil și a măsurilor de protecție adecvate. Orange System va asigura că orice transfer de date în afara Republicii Moldova se realizează în conformitate cu cerințele legale.</div>
</div>

<div class="tab">
          <input type="checkbox" id="faq7">
          <label for="faq7">7. Perioada de Păstrare a Datelor</label>
          <div class="tab-content">
           Jurnalele de activitate și copiile de rezervă ale acestora vor fi păstrate pentru o perioadă predefinită, dar nu mai mică de 12 luni. Alte date vor fi păstrate atât timp cât este necesar pentru îndeplinirea scopurilor pentru care au fost colectate, pentru respectarea obligațiilor legale sau pentru rezolvarea litigiilor, cu respectarea principiului minimizării datelor.
</div>
</div>

<div class="tab">
          <input type="checkbox" id="faq8">
          <label for="faq8">8. Măsuri de Securitate</label>
          <div class="tab-content">
          Orange System implementează măsuri tehnice și organizaționale corespunzătoare și proporționale pentru a gestiona riscurile de securitate a rețelelor și sistemelor informatice. Aceste măsuri vizează asigurarea confidențialității, integrității, disponibilității și autenticității datelor stocate, transmise sau prelucrate și includ:
• Politici de securitate a rețelelor și sistemelor informatice.
• Utilizarea criptografiei și a criptării (ex: end-to-end).
• Controale stricte de acces logic și fizic, inclusiv autentificarea multifactorială pentru conturile privilegiate.
• Măsuri de securitate privind resursele umane (sensibilizare, instruire, verificare a antecedentelor).
• Gestionarea incidentelor, inclusiv monitorizarea și jurnalizarea activităților.
• Planuri de continuitate a activității și recuperare în caz de dezastru, inclusiv gestionarea copiilor de rezervă și a redundanței.
• Protecția împotriva amenințărilor fizice și de mediu.
• Segmentarea rețelelor.
</div>
</div>

<div class="tab">
          <input type="checkbox" id="faq9">
          <label for="faq9">9. Drepturile Persoanei Vizate</label>
          <div class="tab-content">
           În conformitate cu legislația privind protecția datelor cu caracter personal, aveți următoarele drepturi:
• Dreptul de acces la datele dumneavoastră.
• Dreptul de rectificare a datelor inexacte sau incomplete.
• Dreptul la ștergerea datelor (dreptul de a fi uitat).
• Dreptul la restricționarea prelucrării.
• Dreptul de a vă opune prelucrării datelor.
• Dreptul la portabilitatea datelor.
• Dreptul de a depune o plângere la autoritatea de supraveghere competentă (Centrul Național pentru Protecția Datelor cu Caracter Personal).
Pentru exercitarea acestor drepturi, vă rugăm să ne contactați utilizând datele de contact de mai jos.
</div>
</div>

<div class="tab">
          <input type="checkbox" id="faq10">
          <label for="faq10">10. Modificări ale Politicii de Confidențialitate</label>
          <div class="tab-content">
           Jurnalele de activitate și copiile de rezervă ale acestora vor fi păstrate pentru o perioadă predefinită, dar nu mai mică de 12 luni. Alte date vor fi păstrate atât timp cât este necesar pentru îndeplinirea scopurilor pentru care au fost colectate, pentru respectarea obligațiilor legale sau pentru rezolvarea litigiilor, cu respectarea principiului minimizării datelor.
</div>
</div>

<div class="tab">
          <input type="checkbox" id="faq11">
          <label for="faq11">11. Contact</label>
          <div class="tab-content">
           Pentru orice întrebări sau solicitări legate de prezenta Politică de Confidențialitate sau de prelucrarea datelor dumneavoastră, ne puteți contacta la: [Adresa de e-mail / Numărul de telefon / Adresa poștală a Orange System].</div>
</div>
</div>
</div>
<footer class="footer">
      <span>© 2025 Toate drepturile sunt rezervate.</span>
      <a href="#">Suport</a>
    </footer>
  `;
}
document.addEventListener("click", (e) => {
    const target = e.target;
    if (target instanceof Element && target.matches(".read-more")) {
        e.preventDefault();

        const moreText = target.previousElementSibling;
        if (moreText instanceof HTMLElement) {
            if (moreText.style.display === "none") {
                moreText.style.display = "inline";
                target.textContent = "Mai puțin";
            } else {
                moreText.style.display = "none";
                target.textContent = "Mai mult";
            }
        }
    }
});
