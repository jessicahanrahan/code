using System;
using System.Collections;
using System.Collections.Generic;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.stringcalculator
{
    [Subject(typeof(StringCalculator))]
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<StringCalculator>
    {

    };

    public class when_adding_two_strings : concern
    {
        public class and_it_is_an_empty_string
        {
            static int result;
            static string input_value_string;

            Establish c = () =>
            {
                input_value_string = "";
            };

            Because b = () =>
                result = sut.add(input_value_string);

            It returns_zero_when_provided_an_empty_string = () =>
                result.ShouldEqual(0);
        }

        public class and_it_is_one_number
        {
            static int result;
            static string input_value_string;

            Establish c = () =>
            {
                input_value_string = "1";
            };

            Because b = () =>
                result = sut.add(input_value_string);

            It returns_same_value_when_provided_with_one_input = () =>
                result.ToString().ShouldEqual(input_value_string);
        }
        public class and_it_is_two_numbers
        {
            static int result;
            static string input_value_string;

            Establish c = () =>
            {
                input_values = depends.on<ICreateInputValuesFromString>();
                input_value_string = "1,2";

                IList<InputValue> 
                input_values.setup()
            };

            Because b = () =>
                result = sut.add(input_value_string);

            It converts_string_into_inputs = () =>
                

            It returns_the_sum_when_provided_with_two_inputs = () =>
                result.ShouldEqual(3);

            static IEnumerable<InputValue> input_values;
            static ICreateInputValuesFromString input_value_factory;
        }
    }
}
