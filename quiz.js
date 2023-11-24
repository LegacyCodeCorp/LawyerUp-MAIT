const questions = [
    {
        question: "What is child helpline in india?",
        answers:[
            {text: "1004", correct: false},
            {text: "1098", correct: true},
            {text: "1007", correct: false},
            {text: "9810", correct: false},
        ]
    },
    {
        question: "Which among the following is not one of the right granted under the  'Personal liberty and Protection of life'",
        answers:[
            {text: "Right to speech", correct: false},
            {text: "Right to hear", correct: false},
            {text: "Right to vote", correct: true},
            {text: "Right to speedy trial", correct: false},
        ]
    },
    {
        question: " Which Article of the Indian Constitution specifically mentions the fundamental rights of children?",
        answers:[
            {text: "Article 14", correct: false},
            {text: "Article 15", correct: false},
            {text: "Article 21", correct: false},
            {text: "Article 21A", correct: true},
        ]
    },
    {
        question: "What does Article 15 of the Indian Constitution prohibit with respect to children? ",
        answers:[
            {text: "Discrimination on the grounds of religion, race, caste, sex, or place of birth", correct: true},
            {text: "Forced labor and child labor", correct: false},
            {text: "Child marriage", correct: false},
            {text: " Child trafficking", correct: false},
        ]
    },
    {
        question: "Which fundamental right ensures that every child has the right to free and compulsory education? ",
        answers:[
            {text: "Right to Equality", correct: false},
            {text: "Right to Freedom", correct: false},
            {text: " Right to Education", correct: true},
            {text: " Right to Protection from Exploitation", correct: false},
        ]
    },
    {
        question: " According to the Right to Education Act, what is the age range for children to receive free and compulsory education in India?",
        answers:[
            {text: "3-6 years", correct: false},
            {text: "6-14 years", correct: true},
            {text: "14-18 years", correct: false},
            {text: " 18-21years", correct: false},
        ]
    },
    {
        question: "Which fundamental right guarantees children the right to life and personal liberty? ",
        answers:[
            {text: "Right to Equality", correct: false},
            {text: "Right to Freedom", correct: false},
            {text: "Child marriage", correct: false},
            {text: "  Right to Protection from Exploitation", correct: true},
        ]
    },
    {
        question: "What is the main objective of Article 24 of the Indian Constitution? ",
        answers:[
            {text: "Prohibiting child marriage", correct: false},
            {text: "Prohibiting child labor", correct: true},
            {text: "Ensuring free education for children", correct: false},
            {text: "  Ensuring protection of children from discrimination", correct: false},
        ]
    },
    {
        question: "What does the term 'child' typically refer to under Indian law? ",
        answers:[
            {text: "Individuals under 10 years of age", correct: false},
            {text: "Individuals under 12 years of age", correct: false},
            {text: "Individuals under 14 years of age", correct: true},
            {text: "Individuals under 16 years of age", correct: false},
        ]
    },
    {
        question: "Which constitutional amendment introduced Article 21A, making education a fundamental right for children in India? ",
        answers:[
            {text: "42nd Amendment", correct: false},
            {text: "44th Amendment", correct: false},
            {text: "86th Amendment", correct: true},
            {text: "92nd Amendment", correct: false},
        ]
    }
];

const questionElement  = document.getElementById("question");
const answerButtons  = document.getElementById("answer-buttons");
const nextButton  = document.getElementById("next-btn");

let  currentQuestionIndex = 0;
let score = 0;
function startQuiz(){
    currentQuestionIndex = 0;
    score = 0;
    nextButton.innerHTML = "NEXT";
    showQuestion();
}

function showQuestion(){
    resetState();
    let currentQuestion = questions[currentQuestionIndex];
    let questionNo =  currentQuestionIndex  + 1;
    questionElement.innerHTML = questionNo + "."+currentQuestion.question;


    currentQuestion.answers.forEach(answer => {
        const button = document.createElement("button");
        button.innerHTML  = answer.text;
        button.classList.add('btn');
        answerButtons.appendChild(button);
        if(answer.correct){
            button.dataset.correct = answer.correct;
        }
        button.addEventListener("click",selectAnswer);
    });
}


function  resetState(){
    nextButton.style.display = "none";
    while(answerButtons.firstChild){
        answerButtons.removeChild(answerButtons.firstChild);
    }
}

function selectAnswer(e){
    const selectedBtn = e.target;
    const isCorrect = selectedBtn.dataset.correct === "true";
    if(isCorrect){
        selectedBtn.classList.add("correct");
        score++;

    }else{
        selectedBtn.classList.add("incorrect");
    }
    Array.from(answerButtons.children).forEach(button => {
        if(button.dataset.correct  === "true"){
            button.classList.add("correct");
        }
        button.disabled =  true;
    });
    nextButton.style.display =  "block";
}

function showScore(){
    resetState();
    questionElement.innerHTML=`You scored ${score} out of ${questions.length}`;
    nextButton.innerHTML="Play Again";
    nextButton.style.display="block";
}


function handleNextButton(){
    currentQuestionIndex++;
    if(currentQuestionIndex < questions.length){
        showQuestion();
    }else{
        showScore();
    }
}

nextButton.addEventListener("click"  , ()=>{
    if(currentQuestionIndex < questions.length){
        handleNextButton();
    }else{
        startQuiz();
    }
});


startQuiz();

