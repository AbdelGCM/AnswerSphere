const questionUrl = "/api/QuestionsAPI";
const questionConnection = new signalR.HubConnectionBuilder().withUrl("/answerHub").build();

questionConnection.start()
    .catch(function (err) { return console.error(err.toString()) });

document.getElementById("deletebt").addEventListener("click", function (event) {
    var questionId = document.getElementById("questionId").value;

    fetch(`${questionUrl}/${questionId}`, {
        method: "DELETE",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
    .then(() => {
        questionConnection.invoke("SendMessage").catch(function (err) {
            return console.error(err.toString());
        });
    })
    .catch(error => alert("Erreur API"));

    event.preventDefault();
});
