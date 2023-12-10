const questionUrl = "/api/QuestionsAPI";
const questionConnection = new signalR.HubConnectionBuilder().withUrl("/answerHub").build();

questionConnection.start()
    .catch(function (err) { return console.error(err.toString()) });

document.getElementById("editbt").addEventListener("click", function (event) {
    var questionId = document.getElementById("questionId").value;
    var questionLibelle = document.getElementById("questionLibelle").value;

    const question = {
        questionId: questionId,
        questionLibelle: questionLibelle
    };

    fetch(`${questionUrl}/${questionId}`, {
        method: "PUT",
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
