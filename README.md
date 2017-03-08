# HelloWorld Caller

This is the companion app to the [Hello World](https://github.com/PHeonix25/lambda-helloworld) that I wrote to accompany my presentation on AWS Lambda basics at the Amsterdam .Net user-group.

## Disclaimers!

This repo is really nothing special! It's a simple `dotnet core` application that uses the Amazon SDK to make a call out to a Lambda function that we host. 

Strings and input are hard-coded, there are no tests, and everything fits on a single screen at 200% zoom (so: PRESENTATION code, not PRODUCTION code) - use at your own peril.

This might come in handy if someone is looking for the absolute simplest example of how to call a Lambda function from .NET.

## How does it work

- `dotnet restore` will pull down the AWS SDK for Lambda: `AWSSDK.Lambda`
- `dotnet run` will execute the Program.cs - TA DAAA!

I hope the code is pretty self-explanatory, but at a pseudo-code level, it does the following:

- Create a client for the Amazon SDK, tied to a specific region
- Builds an `InvokeRequest` object with the Payload and LogType set
- Uses the client to invoke the request
- Convert the response payload back into a string (for our console output)
- Unencodes the logging output from a base64 string back into a UTF-8 output
- Dumps a whole bunch of output back to the console for demo purposes!