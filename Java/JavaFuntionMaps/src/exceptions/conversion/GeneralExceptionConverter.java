package exceptions.conversion;

import java.util.HashMap;
import java.util.function.Function;

import exceptions.SystemException;

/**
 * Default implementation of the ExceptionConverter to handle the standard exceptions that 
 * can be thrown. Different implementations can be made to handle exception types come from 
 * more specialized systems
 */
public class GeneralExceptionConverter implements ExceptionConverter {

	private final HashMap<Class<?>, Function<Exception, SystemException>> typeConversionMap;
	
	public GeneralExceptionConverter() {
		typeConversionMap = createLookupMap();
	}
	
	@Override
	public SystemException convertException( final Exception exceptionToConvert ) {
		Class<?> exceptionType = exceptionToConvert.getClass();
		SystemException convertedType =typeConversionMap.containsKey( exceptionType ) 
												? typeConversionMap.get( exceptionType ).apply( exceptionToConvert )
												: exceptionExplainingUnhandledType( exceptionToConvert );
		
		return convertedType;
	}
	
	private SystemException exceptionExplainingUnhandledType( final Exception unknownType ) {
		String message = String.format( "An exception of unknown type %s occurred. Exception message was: %s",
										unknownType.getClass().getName(),
										unknownType.getMessage() );
		return new SystemException( message );
	}
	
	private HashMap<Class<?>, Function<Exception, SystemException>> createLookupMap() {
		return new HashMap<>();
	}

}