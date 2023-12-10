const questionUrl = "/api/QuestionsAPI";
const questionConnection = new signalR.HubConnectionBuilder().withUrl("/answerHub").build();

questionConnection.start()
    .catch(function (err) { return console.error(err.toString()) });

document.getElementById("createbt").addEventListener("click", function (event) {
    var questionLibelle = document.getElementById("questionLibelle").value;

    const question = {
        questionId: 0,
        questionLibelle: questionLibelle
    };

    fetch(questionUrl, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(question)
    })
    .then(response => response.json())
    .then(() => {
        questionConnection.invoke("SendMessage").catch(function (err) {
            return console.error(err.toString());
        });
    })
    .catch(error => alert("Erreur API"));

    event.preventDefault();
});
