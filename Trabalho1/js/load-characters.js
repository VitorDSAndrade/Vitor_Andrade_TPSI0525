window.addEventListener("DOMContentLoaded", () => {
  const table = document.getElementById("character-table");
  const characters = JSON.parse(localStorage.getItem("characters")) || [];

  characters.forEach((char, index) => {
    const row = document.createElement("tr");

    const isProtected = index === 0 || index === 1;

    const actions = isProtected
      ? `<span style="color: #777;">Example</span>`
      : `
        <button onclick="editCharacter(${index})" class="btn">🖉</button>
        <button onclick="deleteCharacter(${index})" class="btn">🗑️</button>
      `;

    // Corrigir o caminho se for relativo (../img/) ou base64
    let imageSrc = "";
    if (char.image.startsWith("data:image")) {
      imageSrc = char.image;
    } else if (char.image.startsWith("../") || char.image.startsWith("./") || char.image.startsWith("img/")) {
      imageSrc = char.image;
    } else {
      // fallback (opcional)
      imageSrc = "../img/default.png";
    }

    row.innerHTML = `
      <td><img src="${imageSrc}" alt="${char.name}" class="character-img" style="cursor:pointer; width:80px; height:80px; border-radius:8px; object-fit:cover;"></td>
      <td><b>${char.name}</b></td>
      <td><i>${char.race}</i></td>
      <td><i>${char.class}</i></td>
      <td>${actions}</td>
    `;

    table.appendChild(row);
  });

  // === Modal para Imagem ===
  const modal = document.getElementById("imageModal");
  const modalImg = document.getElementById("modalImage");
  const close = document.querySelector(".close-modal");

  document.querySelectorAll(".character-img").forEach((img) => {
    img.addEventListener("click", () => {
      modal.style.display = "block";
      modalImg.src = img.src;
    });
  });

  close.onclick = () => {
    modal.style.display = "none";
  };

  modal.onclick = (e) => {
    if (e.target === modal) {
      modal.style.display = "none";
    }
  };
});


// === Função para Editar Personagem ===
window.editCharacter = function(index) {
  if (index === 0 || index === 1) return;
  window.location.href = `page3.html?edit=${index}`;
};

// === Função para Apagar Personagem ===
window.deleteCharacter = function(index) {
  if (index === 0 || index === 1) {
    alert("You cannot delete example characters.");
    return;
  }

  if (confirm("Are you sure you want to delete this character?")) {
    let characters = JSON.parse(localStorage.getItem("characters")) || [];
    characters.splice(index, 1);
    localStorage.setItem("characters", JSON.stringify(characters));
    location.reload();
  }
};
