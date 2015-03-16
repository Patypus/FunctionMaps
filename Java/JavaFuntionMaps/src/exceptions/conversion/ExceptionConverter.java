package exceptions.conversion;

import exceptions.SystemException;

/**
 * Interface defining a class which can convert internal exceptions to the type to be shown to the 
 * classes outside the system
 */
public interface ExceptionConverter {

	/**
	 * Method to convert the exception of the internal type to a type which external systems and classes
	 * can use.
	 * @param exceptionToConvert - The exception of an internal type to convert
	 * @return Exception type for external classes or systems.
	 */
	SystemException convertException( final Exception exceptionToConvert );
	
}