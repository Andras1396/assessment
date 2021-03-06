const basicNums = {
    1: "one",
    2: "two",
    3: "three",
    4: "four",
    5: "five",
    6: "six",
    7: "seven",
    8: "eight",
    9: "nine",
    10: "ten",
    11: "eleven",
    12: "twelve",
    13: "thirteen",
    14: "fourteen",
    15: "fifteen",
    16: "sixteen",
    17: "seventeen",
    18: "eighteen",
    19: "nineteen",
    20: "twenty",
    30: "thirty",
    40: "forty",
    50: "fifty",
    60: "sixty",
    70: "seventy",
    80: "eighty",
    90: "ninety" 
}

function showResultOnPage(num){
    document.getElementById("numberInText").innerHTML = getTextFromNumber(num);
}

function getTextFromNumber(num){    
  let sliceFrom = 0;
  let textOfNum = "";
  let isFirst = true;
  let currentSchema = [];
  const additionalText = [" billion", " million", " thousand", ""].reverse(); 

  if(!checkInput(num)) return "Please type a valid number between 0 and one trillion";
  
  if(1100 <= num && num < 2000 ) currentSchema = [2, 2];
  else{
    let counter = 1;
    let lengthOfNum = num.length;
    while(lengthOfNum > 0){
      oneOrTwo = (counter % 2 != 0 && lengthOfNum-2 >= 0 ? 2 : 1);
      currentSchema.push(oneOrTwo);
      lengthOfNum -= oneOrTwo;
      counter++;
    }
  }    

  for(let i = 0; i < currentSchema.length; i++){            
    sliceFrom += - currentSchema[i];
    let currentNumber = getOneOrTwoDigitNums(num.slice(sliceFrom, (i == 0 ? num.length : sliceFrom + currentSchema[i])));  
    if(i%2 != 0 && currentNumber != "") textOfNum = currentNumber + " hundred " + textOfNum
    else if(i%2 == 0 && (currentNumber != "" || num.slice(-((i+3)+(i/2)), -((i+3)+(i/2))+1) > 0)) textOfNum = currentNumber + additionalText[i/2] + " " + textOfNum 
    isFirst = false;
  }
  
  return textOfNum.replace(/^\s+|\s+$/g, '').replace(/  +/g, ' ');    

  function getOneOrTwoDigitNums(number){
    switch(true) {
      case Number(number) == 0 : return (num.length == 1 ? "zero" : "");
      case Number(number) in basicNums : return (num.length > 2 && isFirst ? "and " : "") + basicNums[Number(number)];
      default : return (num.length > 2 && isFirst ? "and " : "") + basicNums[number.charAt(0) + "0"] + "-" + basicNums[number.charAt(1)];
    }
  }

  function checkInput(number) { 
    let reg = new RegExp('^((?!(0))[0-9]{1,12})$');          
    return reg.test(number) || (number == "0") ? true: false;
  }
}

module.exports = getTextFromNumber;




