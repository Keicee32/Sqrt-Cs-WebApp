using System;
using Microsoft.AspNetCore.Mvc;

namespace Keiceeweb.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Root()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Root(string firstNumber, string secondNumber)
        {
            int firstNum = int.Parse(firstNumber);
            int secondNum = int.Parse(secondNumber);

            ViewBag.Contain = firstNum;
            ViewBag.Contain2 = secondNum;
            
            double number1 = Math.Sqrt(Convert.ToDouble(firstNumber));
            double number2 = Math.Sqrt(Convert.ToDouble(secondNumber));

            ViewBag.Result1 = number1;
            ViewBag.Result2 = number2;

            if ((firstNumber is null) || (secondNumber is null)) {
                        ViewBag.ErrorMessage = "Cannot be empty. Please provide values!!";
                    }

            try{
                if((ViewBag.Result1 != null) && (ViewBag.Result2 != null)) {
                    if(ViewBag.Result1 > ViewBag.Result2){
                        ViewBag.Result = "The number " + ViewBag.Contain + " with Square root of " + ViewBag.Result1 + " is greater than the number " + ViewBag.Contain2 + " with Square root of " + ViewBag.Result2;
                    } else if(ViewBag.Result1 < ViewBag.Result2){
                        ViewBag.Result = "The number " + ViewBag.Contain2 + " with Square root of " + ViewBag.Result2 + " is greater than the number " + ViewBag.Contain + " with Square root of " + ViewBag.Result1;
                    } else if(ViewBag.Result1 == ViewBag.Result2){
                        ViewBag.Result = "Numbers with the same square roots are not allowed. Please enter another value";
                    } else if ((ViewBag.Contain < 0) || (ViewBag.Contain2 < 0)) {
                        ViewBag.Result = "Please use positive numbers only!!";
                    } else{
                        ViewBag.Result = "Cannot be empty. Please provide values";
                    }
                } else{
                    ViewBag.Result = "Cannot be empty. Please provide values";
                }
            } catch(System.FormatException e){
                ViewBag.Message = e.Message;
            }
            

            return View();
        }
    }
}