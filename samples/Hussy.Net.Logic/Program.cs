/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

// Print all even numbers from 1 to 10.
// The function EV takes in a numeric value
// and determines if it is even or not.
W("Even");
Ws();
Gr(10).F(Ev).E(W);

// Print all odd numbers from 1 to 10.
// The function OD takes in a numeric value
// and determines if it is odd or not.
Wh("Odd");
Ws();
Gr(10).F(Od).E(W);

// Print all numbers between 1 and 100
// that are divisible by 3 and 5.
// The function MD extends numeric types
// determining if the instance value
// is divisible by all the specified operands.
Wh("Modulus");
Ws();
Gr(100).F(x => x.Dvb(3, 5)).E(W);