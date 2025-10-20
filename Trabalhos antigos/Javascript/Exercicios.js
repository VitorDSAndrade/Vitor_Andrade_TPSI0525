
const prompt = require('prompt-sync')();

function menu() {
  let opcao;

  do {
    console.log("\n===== MENU EXERCÍCIOS =====");
    console.log("1 - 30 primeiros pares e ímpares");
    console.log("2 - Verificar se 10 números são pares ou ímpares");
    console.log("3 - Média de 10 alunos");
    console.log("4 - Verificar se número é primo");
    console.log("5 - Mostrar de 1 a 10000");
    console.log("6 - Mostrar 10 primeiros primos");
    console.log("7 - Série de 10 em 10 até 1000");
    console.log("8 - Duas séries (10 em 10 e 15 em 10)");
    console.log("9 - Validar número entre 1 e 100");
    console.log("10 - Contar divisores");
    console.log("11 - Padrão de números");
    console.log("12 - Operações até número");
    console.log("13 - Tabuada de 1 número");
    console.log("14 - Tabuadas de 1 a 100");
    console.log("15 - Códigos ASCII de 0 a 255");
    console.log("16 - Média de 30 pares entre 1 e 50");
    console.log("17 - Múltiplos de 5 que não são de 3");
    console.log("18 - Contar números perfeitos");
    console.log("19 - Série de Fibonacci até 60 termos");
    console.log("0 - Sair");

    opcao = parseInt(prompt("Escolhe uma opção: "));

    switch (opcao) {
      case 1:
        for (let i = 1, p = 2; i <= 30; i++, p += 2) {
          console.log("Ímpar: " + (i * 2 - 1) + " | Par: " + p);
        }
        break;
      case 2:
        for (let i = 1; i <= 10; i++) {
          let n = parseInt(prompt("Número " + i + ": "));
          if (n % 2 == 0) {
            console.log(n + " é par");
          } else {
            console.log(n + " é ímpar");
          }
        }
        break;
      case 3:
        let somaNotas = 0;
        for (let i = 1; i <= 10; i++) {
          let nota = parseFloat(prompt("Nota do aluno " + i + ": "));
          somaNotas += nota;
        }
        console.log("Média: " + (somaNotas / 10));
        break;
      case 4:
        let num = parseInt(prompt("Digite um número: "));
        let primo = true;
        if (num <= 1) primo = false;
        for (let i = 2; i < num; i++) {
          if (num % i == 0) primo = false;
        }
        console.log(primo ? "É primo" : "Não é primo");
        break;
      case 5:
        for (let i = 1; i <= 10000; i++) {
          console.log(i);
        }
        break;
      case 6:
        let contador = 0;
        let atual = 2;
        while (contador < 10) {
          let ePrimo = true;
          for (let i = 2; i < atual; i++) {
            if (atual % i == 0) ePrimo = false;
          }
          if (ePrimo) {
            console.log(atual);
            contador++;
          }
          atual++;
        }
        break;
      case 7:
        for (let i = 10; i <= 1000; i += 10) {
          console.log(i);
        }
        break;
      case 8:
        for (let i = 10; i <= 1000; i += 10) console.log(i);
        for (let i = 15; i <= 995; i += 10) console.log(i);
        break;
      case 9:
        let numero;
        do {
          numero = parseInt(prompt("Digite número entre 1 e 100:"));
        } while (numero < 1 || numero > 100);
        console.log("Número válido: " + numero);
        break;
      case 10:
        let valor = parseInt(prompt("Digite um número:"));
        let totalDiv = 0;
        for (let i = 1; i <= valor; i++) {
          if (valor % i == 0) totalDiv++;
        }
        console.log("Total de divisores: " + totalDiv);
        break;
      case 11:
        for (let i = 1; i <= 5; i++) {
          let linha = "";
          for (let j = 1; j <= i; j++) linha += i;
          console.log(linha);
        }
        break;
      case 12:
        let lim = parseInt(prompt("Número limite:"));
        let operacoes = 0;
        for (let i = 1; i < lim; i++) {
          console.log(lim + "+" + i + "=" + (lim + i));
          console.log(lim + "-" + i + "=" + (lim - i));
          console.log(lim + "*" + i + "=" + (lim * i));
          console.log(lim + "/" + i + "=" + (lim / i).toFixed(2));
          operacoes += 4;
        }
        console.log("Total de operações: " + operacoes);
        break;
      case 13:
        let tab = parseInt(prompt("Tabuada de qual número?"));
        for (let i = 1; i <= 10; i++) {
          console.log(tab + " x " + i + " = " + (tab * i));
        }
        break;
      case 14:
        for (let i = 1; i <= 100; i++) {
          console.log("Tabuada de " + i);
          for (let j = 1; j <= 10; j++) {
            console.log(i + " x " + j + " = " + (i * j));
          }
        }
        break;
      case 15:
        for (let i = 0; i <= 255; i++) {
          console.log(i + " = " + String.fromCharCode(i));
          if (i % 20 == 0 && i != 0) {
            let continuar = prompt("Continuar? (s/n): ").toLowerCase();
            if (continuar !== 's') break;
          }
        }
        break;
      case 16:
        let somaPares = 0;
        let validos = 0;
        while (validos < 30) {
          let n = parseInt(prompt("Digite número par entre 1 e 50:"));
          if (n % 2 == 0 && n >= 1 && n <= 50) {
            somaPares += n;
            validos++;
          }
        }
        console.log("Média: " + (somaPares / 30));
        break;
      case 17:
        for (let i = 1; i <= 1000; i++) {
          if (i % 5 == 0 && i % 3 != 0) console.log(i);
        }
        break;
      case 18:
        let ate = parseInt(prompt("Verificar até qual número:"));
        for (let i = 1; i <= ate; i++) {
          let soma = 0;
          for (let j = 1; j < i; j++) {
            if (i % j == 0) soma += j;
          }
          if (soma == i) console.log(i + " é perfeito");
        }
        break;
      case 19:
        let a = 1, b = 1;
        console.log(a);
        console.log(b);
        for (let i = 3; i <= 60; i++) {
          let c = a + b;
          console.log(c);
          a = b;
          b = c;
        }
        break;
      case 0:
        console.log("A sair...");
        break;
      default:
        console.log("Opção inválida");
    }
  } while (opcao !== 0);
}

menu();
