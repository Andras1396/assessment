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

function getTextFromNumber(num){    
  let sliceFrom = 0;
  let textOfNum = "";
  let isFirst = true;
  let currentSchema = [];
  const additionalText = [" hundred", " million", " hundred", " thousand", " hundred", ""].reverse();  
  
  if(num.length == 4 && (num.substring(0, 2) > 10 && num.substring(0, 2) < 20)) currentSchema = [2, 2];
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
    textOfNum = (currentNumber != "" ? currentNumber + additionalText[i] : (i == 2 && num.length > 3 && num.length < 7 ?  additionalText[i] : (i == 4 && num.length > 6 && num.length < 10 ?  additionalText[i] : ""))) + " " + textOfNum; 
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
}

module.exports = getTextFromNumber;




