const questionUrl = "/api/QuestionsAPI";
let $questions = $("#questions");
getQuestions();

function getQuestions() {
    fetch(questionUrl)
        .then(response => response.json())
        .then(data => data.forEach(question => {
            let template = `<tr>
                <td>${question.questionLibelle}</td>
                <td>
                    <a href="/Questions/Edit/${question.questionId}">Edit</a> |
                    <a href="/Questions/Details/${question.questionId}">Details</a> |
                    <a href="/Questions/Delete/${question.questionId}">Delete</a>
                </td>
            </tr>`;
            $questions.append($(template));
        }))
        .catch(error => alert("Erreur API"));
}

const questionConnection = new signalR.HubConnectionBuilder().withUrl("/AnswerHub").build();
questionConnection.start()
    .catch(function (err) { return console.error(err.toString()) });

questionConnection.on("AnswerChange", function () {
    $questions.empty();
    getQuestions();
});
