document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("character-form");
  const preview = document.getElementById("preview");
  const fileInput = document.getElementById("image");

  const urlParams = new URLSearchParams(window.location.search);
  const editIndex = urlParams.get("edit");

  let characters = JSON.parse(localStorage.getItem("characters")) || [];
  let currentImage = ""; // imagem antiga ou nova

  // SE ESTIVER NO MODO EDITAR
  if (editIndex !== null && characters[editIndex]) {
    const char = characters[editIndex];

    // Preencher os campos
    document.getElementById("name").value = char.name;
    document.getElementById("race").value = char.race;
    document.getElementById("class").value = char.class;
    document.getElementById("backstory").value = char.backstory;

    document.getElementById("str").value = char.stats.str;
    document.getElementById("dex").value = char.stats.dex;
    document.getElementById("con").value = char.stats.con;
    document.getElementById("int").value = char.stats.int;
    document.getElementById("wis").value = char.stats.wis;
    document.getElementById("cha").value = char.stats.cha;

    // Mostrar imagem antiga
    if (char.image) {
      preview.src = char.image;
      preview.style.display = "block";
      currentImage = char.image; // armazenar
    }
  }

  // Preview ao selecionar nova imagem
  fileInput.addEventListener("change", () => {
    const file = fileInput.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = function (e) {
        preview.src = e.target.result;
        preview.style.display = "block";
        currentImage = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  });

  form.addEventListener("submit", (e) => {
    e.preventDefault();

    const character = {
      name: document.getElementById("name").value,
      race: document.getElementById("race").value,
      class: document.getElementById("class").value,
      backstory: document.getElementById("backstory").value,
      image: currentImage, // mantém a imagem anterior ou nova
      stats: {
        str: parseInt(document.getElementById("str").value),
        dex: parseInt(document.getElementById("dex").value),
        con: parseInt(document.getElementById("con").value),
        int: parseInt(document.getElementById("int").value),
        wis: parseInt(document.getElementById("wis").value),
        cha: parseInt(document.getElementById("cha").value),
      },
    };

    if (editIndex !== null && characters[editIndex]) {
      // Atualizar personagem existente
      characters[editIndex] = character;
    } else {
      // Adicionar novo personagem
      characters.push(character);
    }

    localStorage.setItem("characters", JSON.stringify(characters));
    window.location.href = "../pages/page1.html";
  });
});
