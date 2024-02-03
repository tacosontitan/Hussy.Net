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

// Hussy has a built-in hello world module.
// It's default output is "Hello, world!".
W("Default");
Ws();
Yo();

// If you need a common variation of the output,
// then you can specify a variant ID to change it.
Wh("Default (variant)");
Ws();
Yo(1);

// If a predefined variant doesn't exist,
// then you can always write it from scratch:
Wh("Custom");
Ws();
W("...hello...world...");