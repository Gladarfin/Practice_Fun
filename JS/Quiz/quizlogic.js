const startBtn = document.getElementById('start-btn');
const nextBtn = document.getElementById('next-btn');
startBtn.addEventListener('click', startQuiz);
const questionContainer = document.getElementById('question-container');
const dropAnswersElem = document.getElementById('drop-targets');
const answerContainer = document.getElementById('answers-container');
let shuffledQuestions, currentQuestionIndex;
const questionElement = document.getElementById('question');
let resultAnswers = [];
let correctAnswersCount = 0;
let questionsJSON, answersJSON;

startBtn.addEventListener('click', startQuiz);
nextBtn.addEventListener('click', () => {
    currentQuestionIndex++;
    addToResult();
    if (nextBtn.innerText != "Result") {
        setNextQuestion();
    } else {
        showResult();
    }
})

function startQuiz() {
    startBtn.classList.add('hide');
    questionContainer.classList.remove('hide');
    answerContainer.classList.remove('hide');
    nextBtn.innerText = "Next";
    loadJSON();
    shuffledQuestions = questionsJSON.sort(() => Math.random() - 0.5);
    currentQuestionIndex = 0;
    setNextQuestion();
}

function loadJSON() {
    let request = new XMLHttpRequest();
    request.open("GET", "questions.json", false);
    request.send(null);
    questionsJSON = JSON.parse(request.responseText);
    request.open("GET", "answers.json", false);
    request.send(null);
    answersJSON = JSON.parse(request.responseText);
}

function setNextQuestion() {
    showQuestion(shuffledQuestions[currentQuestionIndex]);
}

function showQuestion(question) {
    resetState();
    questionElement.innerText = question.question;
    for (let i = 0; i < question.answersCount; i++) {
        createAnswerBox(i + 1);
        createAnswer(i + 1);
    }
    answerContainer.classList.remove('hide');
    addDragAndDrop(boxes);
    addELToImages(images);
}

function createAnswerBox(index) {
    const newAnswerBox = document.createElement('div');
    newAnswerBox.classList.add('box');
    newAnswerBox.setAttribute('id', 'div' + index);
    dropAnswersElem.appendChild(newAnswerBox);
}

function createAnswer(index) {
    const newAnswer = document.createElement('img');
    newAnswer.classList.add('item');
    const answerAttr = 'robot' + index;
    newAnswer.setAttribute('id', answerAttr);
    newAnswer.setAttribute('src', "imgs/" + answerAttr + '.png');
    imgContainer.appendChild(newAnswer);
}

function resetState() {
    nextBtn.classList.add('hide');
    while (dropAnswersElem.firstChild) {
        dropAnswersElem.removeChild(dropAnswersElem.lastChild);
    }
    while (imgContainer.firstChild) {
        imgContainer.removeChild(imgContainer.lastChild);
    }
    answerContainer.classList.add('hide');
}

function showNextButton() {
    if (shuffledQuestions.length == currentQuestionIndex + 1) {
        nextBtn.innerText = "Result";
    }
    nextBtn.classList.remove('hide');
}

function addHideClass(elem) {
    elem.classList.add('hide');
}

function addToResult() {
    let tmpResultString = "";
    const tmpAnswers = document.getElementsByClassName('item');
    for (let i = 0; i < tmpAnswers.length; i++) {
        tmpResultString += tmpAnswers[i].getAttribute('id').replace('robot', '');
    }
    tmpResultString = shuffledQuestions[currentQuestionIndex - 1].questionNumber + tmpResultString;
    resultAnswers.push(tmpResultString);
}
//результаты теста
function showResult() {
    resetState();
    startBtn.innerText = 'Restart';
    startBtn.classList.remove('hide');
    checkAnswers();
}

function checkAnswers() {
    for (let i = 0; i < answersJSON.length; i++) {
        const tmpAnswer = resultAnswers.find(ans => Number(ans[0]) == i + 1);
        if (answersJSON[i].answer == tmpAnswer.substring(1)) {
            correctAnswersCount++;
        }
    }
    questionElement.innerText = 'Correct answers: ' + correctAnswersCount;
}