const numberConverter = require('./number-converter');

it('Invalid input 1', () => 
  expect(numberConverter("00")).toBe("Please type a valid number between 0 and one trillion")
);

it('Invalid input 2', () => 
  expect(numberConverter("asd22")).toBe("Please type a valid number between 0 and one trillion")
);

it('One digit number test 1', () => 
  expect(numberConverter("0")).toBe("zero")
);

it('One digit number test 2', () => 
  expect(numberConverter("5")).toBe("five")
);

it('Two digit number test 1', () => 
  expect(numberConverter("11")).toBe("eleven")
);

it('Two digit number test 2', () => 
  expect(numberConverter("41")).toBe("forty-one")
);

it('Two digit number test 3', () => 
  expect(numberConverter("57")).toBe("fifty-seven")
);

it('Two digit number test 4', () => 
  expect(numberConverter("64")).toBe("sixty-four")
);

it('Two digit number test 5', () => 
  expect(numberConverter("98")).toBe("ninety-eight")
);

it('Two digit number test 6', () => 
  expect(numberConverter("14")).toBe("fourteen")
);

it('Three digit number test 1', () => 
  expect(numberConverter("862")).toBe("eight hundred and sixty-two")
);

it('Three digit number test 2', () => 
  expect(numberConverter("700")).toBe("seven hundred")
);

it('Three digit number test 3', () => 
  expect(numberConverter("405")).toBe("four hundred and five")
);

it('Four digit number test 1 - irregular', () => 
  expect(numberConverter("1862")).toBe("eighteen hundred and sixty-two")
);

it('Four digit number test 2 - irregular', () => 
  expect(numberConverter("1600")).toBe("sixteen hundred")
);

it('Four digit number test 3', () => 
  expect(numberConverter("3002")).toBe("three thousand and two")
);

it('Four digit number test 4', () => 
  expect(numberConverter("4010")).toBe("four thousand and ten")
);

it('Five digit number test 1', () => 
  expect(numberConverter("22411")).toBe("twenty-two thousand four hundred and eleven")
);

it('Six digit number test 1', () => 
  expect(numberConverter("300000")).toBe("three hundred thousand")
);

it('Six digit number test 2', () => 
  expect(numberConverter("212121")).toBe("two hundred twelve thousand one hundred and twenty-one")
);

it('Seven digit number test 1', () => 
  expect(numberConverter("2264532")).toBe("two million two hundred sixty-four thousand five hundred and thirty-two")
);

it('Seven digit number test 2', () => 
  expect(numberConverter("1100756")).toBe("one million one hundred thousand seven hundred and fifty-six")
);

it('Eight digit number test 1', () => 
  expect(numberConverter("64835627")).toBe("sixty-four million eight hundred thirty-five thousand six hundred and twenty-seven")
);

it('Eight digit number test 2', () => 
  expect(numberConverter("11000000")).toBe("eleven million")
);

it('Nine digit number test 1', () => 
  expect(numberConverter("212000121")).toBe("two hundred twelve million one hundred and twenty-one")
);

it('Nine digit number test 1', () => 
  expect(numberConverter("200000001")).toBe("two hundred million and one")
);