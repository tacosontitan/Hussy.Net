// Print all even numbers from 1 to 10.
// The function EV takes in a numeric value
// and determines if it is even or not.
W("Even");
R(10).F(EV).E(W);

// Print all odd numbers from 1 to 10.
// The function OD takes in a numeric value
// and determines if it is odd or not.
WH("Odd");
R(10).F(OD).E(W);

// Print all numbers between 1 and 100
// that are divisible by 3 and 5.
// The function MD extends numeric types
// determining if the instance value
// is divisible by all the specified operands.
WH("Modulus");
R(100).F(x => x.MD(3, 5)).E(W);