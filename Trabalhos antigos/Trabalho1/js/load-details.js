window.addEventListener("DOMContentLoaded", () => {
  const table = document.getElementById("details-table");
  const characters = JSON.parse(localStorage.getItem("characters")) || [];

  characters.forEach((char) => {
    const row = document.createElement("tr");

    // Nome do personagem
    const nameCell = document.createElement("td");
    nameCell.innerHTML = `<b>${char.name}</b>`;

    // Atributos e backstory
    const statsCell = document.createElement("td");
    statsCell.innerHTML = `
      <table>
        <tr><td><i>Strength:</i> ${char.stats.str}</td></tr>
        <tr><td><i>Dexterity:</i> ${char.stats.dex}</td></tr>
        <tr><td><i>Constitution:</i> ${char.stats.con}</td></tr>
        <tr><td><i>Intelligence:</i> ${char.stats.int}</td></tr>
        <tr><td><i>Wisdom:</i> ${char.stats.wis}</td></tr>
        <tr><td><i>Charisma:</i> ${char.stats.cha}</td></tr>
      </table>
      <table>
        <tr><td><i>Backstory:</i> ${char.backstory}</td></tr>
      </table>
    `;

    row.appendChild(nameCell);
    row.appendChild(statsCell);
    table.appendChild(row);
  });
});
