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
		
		//Add an UL of invalid input to child div under error div
		//This overrides all elements currently in innerDiv div
		$(document).ready(function(){    		
        	$("#innerDiv").html("<ul id=\"jqueryUL\">\
					<li>Only numerical values allowed</li>\
					<li>The form must be fully filled out</li>\
					<li>No letters or symbol characters allowed</li>\
					<li>No commas allowed</li>\
					</ul> ");
			//no bullet points in UL
			$("#jqueryUL").css("list-style-type","none");
						
		});	

    } 
    else 
	{
		//if invalid input div was visible, clear it before calculating
		//results as both divs could be presented if the user did not
		//click ok to clear the invalid input div
		document.getElementById("invalidResult").style.display="none";
       	getValues();

    }
}


window.onload = function()
{

    document.getElementById("loanAmount").focus();
    document.getElementById("calculate").onclick = validate;

}

//Removes a div, if the div is not on page, it presents the div instead
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
	//get values from form
    loanTerm = document.getElementById("loanTerm").value;
    apr = document.getElementById("apr").value;
    loanAmount = document.getElementById("loanAmount").value;
	
	//adjust APR
    apr /= 1200;
	//convert years to months
    loanTerm *= 12;
	//calculate payments
    payment = calculatePayment();

    document.getElementById("payment").value = "$" + payment.toFixed(2);
    document.getElementById("validResult").style.display="block";
	
	//JQuery: modify validResult DIV, bold font and blue background
	$(document).ready(function(){    
        $("#validResult").addClass("important blue");    
	});
	
}

//calculates payments on a monthly basis
function calculatePayment()
{
    var payment = loanAmount*(apr * Math.pow((1 + apr), loanTerm))/(Math.pow((1 + apr), loanTerm) - 1);
    return payment;
}
