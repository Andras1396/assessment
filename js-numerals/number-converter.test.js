const numberConverter = require('./number-converter');

it('One digit number test - zero', () => 
  expect(numberConverter("0")).toBe("zero")
);