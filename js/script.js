const stampaTabella = () => {
  $.ajax({
    url: "https://localhost:7148/api/ferramenta",
    type: "GET",
    success: (risultato) => {
      let contenuto = "";

      for (const [idx, item] of risultato.entries()) {
        contenuto += `
                <tr>
                <td>${item.nome}</td>
                <td>${item.descrizione}</td>
                <td>${item.prezzo}</td>
                <td>
                <button type="button" class="btn btn-sm btn-outline-success">
                    +
                </button>
                <span>${item.quantita}</span>
                
                <button type="button" class="btn btn-sm btn-outline-danger">-</button>
                </td>
                <td>${item.categoria}</td>
                <td>${item.dataCreazione}</td>
                <td>
                <button class="btn btn-outline-danger" onclick="elimina('${item.codice}')">Elimina</button>
                </td>
                <td>
                <button class="btn btn-outline-warning"  data-toggle="modal" onclick="valueProdotto('${item.codice}')" data-target="#exampleModal" >Modifica</button>
                </td>
                `;
        console.log(item);
      }
      $("#tabella-prodotti").html(contenuto);
    },
    error: (errore) => {
      alert("ERRORE");
      console.log(errore);
    },
  });
};

const salvaElemento = () => {
  let nome = $("#nome").val();
  let desc = $("#descrizione").val();
  let prez = $("#prezzo").val();
  let quan = $("#quantita").val();
  let cate = $("#categoria").val();

  $.ajax({
    url: "https://localhost:7148/api/ferramenta",
    type: "POST",
    data: JSON.stringify({
      nome: nome,
      descrizione: desc,
      prezzo: prez,
      quantita: quan,
      categoria: cate,
    }),
    contentType: "application/json",
    dataType: "json",
    success: function () {
      alert("Prodotto inserito");
      stampaTabella();
    },
    error: function (errore) {
      alert("Errore");
      console.log(errore);
    },
  });
};

const elimina = (codice) => {
  $.ajax({
    url: "https://localhost:7148/api/ferramenta/codice/" + codice,
    type: "POST",
    success: function () {
      alert("Prodotto Eliminato");
      stampaTabella();
    },
    error: function (errore) {
      alert("Errore");
      console.log(errore);
    },
  });
};

const modifica = (codice) => {
  let nome = $("#modal-nome").val();
  let desc = $("#modal-descrizione").val();
  let prez = $("#modal-prezzo").val();
  let quan = $("#modal-quantita").val();
  let cate = $("#modal-categoria").val();

  $.ajax({
    url: "https://localhost:7148/api/ferramenta",
    type: "PATCH",
    data: JSON.stringify({
      nome: nome,
      codice: codice,
      descrizione: desc,
      prezzo: prez,
      quantita: quan,
      categoria: cate,
    }),
    contentType: "application/json",
    dataType: "json",
    success: function () {
      alert("Prodotto modificato");
      stampaTabella();
    },
    error: function (errore) {
      alert("Errore");
      console.log(errore);
    },
  });
};
const valueProdotto = (codice) => {
  $.ajax({
    url: "https://localhost:7148/api/ferramenta/" + codice,
    type: "GET",
    success: (risultato) => {
      console.log(risultato);

      let mod_nome = $("#modal-nome").val(risultato.nome);
      let mod_codice = $("#modal-codice").val(risultato.codice);
      let mod_desc = $("#modal-descrizione").val(risultato.descrizione);
      let mod_prez = $("#modal-prezzo").val(risultato.prezzo);
      let mod_qnt = $("#modal-quantita").val(risultato.quantita);
      let mod_cat = $("#modal-categoria").val(risultato.categoria);
      let mod_data = $("#modal-codice").val(risultato.data);

      let prodMod = {
        nome: mod_nome,
        descrizione: mod_desc,
        codice: mod_codice,
        prezzo: mod_prez,
        quantita: mod_qnt,
        categoria: mod_cat,
        data: mod_data,
      };
      return prodMod;
    },
  });
};
$(document).ready(function () {
  stampaTabella();

  $("#salva").on("click", () => {
    salvaElemento();
    valueProdotto();
  });
});
