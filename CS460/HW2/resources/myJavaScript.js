//Global variables
var loanTerm;
var apr;
var loanAmount;
var payment;

//VALIDATE INPUT
function validate()
{
    var x;
    var y;
    var z;

    // Get the value of the input fields
    x = document.getElementById("loanAmount").value;
    y = document.getElementById("apr").value;
    z = document.getElementById("loanTerm").value;

    // If x, y or z are not numbers, call error div
    if (isNaN(x) || isNaN(y) || isNaN(z) || x == "" || y == "" || z == "") 
    {
        document.getElementById("invalidResult").style.display="block";
		
		//JQuery function that changes the font color to red
		//it changes the div content to bold fonts and adds a red background
		$(document).ready(function(){
			$("#invalidResult").css("color","red");
			$("#invalidResult").addClass("important red");
		});

    } 
    else 
    {
       getValues();

    }
}


window.onload = function()
{

    document.getElementById("loanAmount").focus();
    document.getElementById("calculate").onclick = validate;

}

//Removes a div
function removeDiv(x)
{
    var divStatus = document.getElementById(x);
    if (divStatus.style.display === "none")
    {
        divStatus.style.display = "block";
    } 
    else 
    {
        divStatus.style.display = "none";
    }
}

//Resets a div and calls removeDiv function
function formReset(x) {
    document.getElementById("myForm").reset();
    removeDiv(x);
}


function getValues()
{                
    loanTerm = document.getElementById("loanTerm").value;
    apr = document.getElementById("apr").value;
    loanAmount = document.getElementById("loanAmount").value;

    apr /= 1200;
    loanTerm *= 12;
    payment = calculatePayment();

    document.getElementById("payment").value = "$" + payment.toFixed(2);
    document.getElementById("validResult").style.display="block";
	
	//JQuery: modify validResult DIV, bold font and blue background
	$(document).ready(function(){    
        $("#validResult").addClass("important blue");    
	});
	
}

function calculatePayment()
{
    var payment = loanAmount*(apr * Math.pow((1 + apr), loanTerm))/(Math.pow((1 + apr), loanTerm) - 1);
    return payment;
}

//$(document).ready(function(){
//    $("button").click(function(){
//        $("h1, h2, p").addClass("blue");
//        $("div").addClass("important");
//    });
//});
//
//$(document).ready(function(){
//    $("button").click(function(){
//        $("p").css("background-color", "yellow");
//    });
//});