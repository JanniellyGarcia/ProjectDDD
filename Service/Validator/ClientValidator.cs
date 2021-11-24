using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Validator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Por favor, insira o CPF.")
                .NotNull().WithMessage("Por favor, insira o CPF.")
                .Must(ValidatorCPF).WithMessage("CPF Invalido!");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Por favor, insira o Endereço.")
                .NotNull().WithMessage("Por favor, insira o Endereço.");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("Por favor, insira o CEP.")
                .NotNull().WithMessage("Por favor, insira o CEP.")
                .Must(ValidaCEP).WithMessage("CPF Invalido!");


        }

        //Função de validação de cpf
        private bool ValidatorCPF(string cpf)
        {
            cpf = RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        // Função de validação de CEP
        public bool ValidaCEP(string cep)

        {

            cep = cep.Replace(".", "");

            cep = cep.Replace("-", "");

            cep = cep.Replace(" ", "");



            Regex Rgx = new Regex(@"^\d{8}$");

            if (!Rgx.IsMatch(cep))

                return false;

            else

                return true;

        }
    }
}
